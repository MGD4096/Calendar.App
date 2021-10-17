import { Component, OnDestroy, OnInit, Output, ViewChild,EventEmitter } from '@angular/core';
import { EventInput } from '@fullcalendar/angular';
import { Subject, Subscription, timer } from 'rxjs';
import { switchMap, takeUntil } from 'rxjs/operators';
import { LangChangeEvent, TranslateService } from '@ngx-translate/core';
import { MatDialog } from '@angular/material/dialog';
import { calendarFormat } from 'moment';
import { MatSnackBar } from '@angular/material/snack-bar';
import { CalendarService } from '../../../_services/Calendar/calendar.service';
import { Calendar } from '../../../_models/Calendar/calendar';
import { MatSort, Sort } from '@angular/material/sort';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import { CreateCalendarComponent } from '../create/create-calendar.component';
import { UpdateCalendarComponent } from '../update/update-calendar.component';
import { DeleteCalendarComponent } from '../delete/delete-calendar.component';
import { SelectionModel } from '@angular/cdk/collections';

  const initialSelection = [];
  const allowMultiSelect = false;
@Component({
  selector: 'calendar-list',
  templateUrl: './calendar-list.component.html'
})
export class CalendarListComponent implements OnInit, OnDestroy {
  //private subsciption: Subscription;
  @Output() checkedItem: EventEmitter<any> = new EventEmitter();
  private subsciption = new Subject<Calendar>();
  public loaded: boolean = false;
  public calendar: Calendar[];
  pageSize = 10;
  pageSizeOptions: number[] = [1, 5, 10, 25, 100];
  displayedColumns: string[] = ['select','calendarId', 'calendarName', 'calendarDescription','actions'];
  dt = new MatTableDataSource<Calendar>([]);
  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;
  pageEvent: PageEvent;
  selection = new SelectionModel<Calendar>(allowMultiSelect, [this.dt.data[0]]);
  
  constructor(
    private calendarService: CalendarService,
    private modalService: MatDialog,
    private toast: MatSnackBar,
    private translate: TranslateService,
  ) {
    
  }
  ngAfterViewInit() {
    this.dt.paginator = this.paginator;
    this.dt.sort = this.sort;
  }
  ngOnInit() {
    this.refreshData();
  }
  resetPaging(): void {
    this.paginator.pageIndex = 0;
  }
  refreshData() {
    this.calendarService.list().pipe(takeUntil(this.subsciption)).subscribe(result => {
      this.calendar = (<Calendar[]>result);
      this.dt.data = result;
      this.dt.paginator = this.paginator;
      this.dt.sort = this.sort;
      this.loaded = true;
    });
  }
  sortData(sort: Sort) {
    const data = this.dt.data.slice();
    if (!sort.active || sort.direction === '') {
      this.dt.data = data;
      return;
    }
    this.dt.data = data.sort((a, b) => {
      const isAsc = sort.direction === 'asc';
      switch (sort.active) {
        case 'calendarId': return this.compare(a.CalendarId, b.CalendarId, isAsc);
        case 'calendarName': return this.compare(a.CalendarName, b.CalendarName, isAsc);
        case 'calendardescription': return this.compare(a.CalendarDescription, b.CalendarDescription, isAsc);
        default: return 0;
      }
    });
  }

  compare(a: number | string, b: number | string, isAsc: boolean) {
    return (a < b ? -1 : 1) * (isAsc ? 1 : -1);
  }
  filterData(obj: any) {
    this.dt.filter = obj.target.value;
  }
  ngOnDestroy() {
    this.subsciption.unsubscribe();
  }
  openAddFormModal() {
    console.log(this.selection.selected)
    const modalRef = this.modalService.open(CreateCalendarComponent);
    modalRef.afterClosed().subscribe(() => { this.refreshData() });
  }
  openEditFormModal(id) {
    const modalRef = this.modalService.open(UpdateCalendarComponent, { data: id });
    modalRef.afterClosed().subscribe(() => { this.refreshData() });
  }
  openDeleteFormModal(id) {
    const modalRef = this.modalService.open(DeleteCalendarComponent, { data: id });
    modalRef.afterClosed().subscribe(() => { this.refreshData() });
  }
  changeSelection(row) {
    this.selection.toggle(row)
    if (this.selection.hasValue && this.selection.selected[0]) {
      this.checkedItem.emit(this.selection.selected[0]['calendarId']);
    } else {
      this.checkedItem.emit(undefined);

    }
  }
}
