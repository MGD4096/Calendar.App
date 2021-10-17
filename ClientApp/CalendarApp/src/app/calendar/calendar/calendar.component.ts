import { Component, OnDestroy, OnInit } from '@angular/core';
import { EventInput } from '@fullcalendar/angular';
import { CalendarOptions } from '@fullcalendar/core';
import plLocale from '@fullcalendar/core/locales/pl';
import enLocale from '@fullcalendar/core/locales/en-gb';
import { Subject, Subscription, timer } from 'rxjs';
import { switchMap } from 'rxjs/operators';
import { ToastrService } from 'ngx-toastr';
import { LangChangeEvent, TranslateService } from '@ngx-translate/core';
import { ChangeDetectorRef } from '@angular/core';
import { CalendarEvent } from '../../../_models/Calendar/calendar.event';
import { CalendarEventService } from '../../../_services/Calendar/calendar.event.service';
import { MatDialog } from '@angular/material/dialog';
import { calendarFormat } from 'moment';
import { CalendarEventFormComponent } from '../calendar-event/form/calendar-event-form.component';
import { CreateCalendarEventComponent } from '../calendar-event/create/create-calendar-event.component';
import { ActionCalendarEventComponent } from '../calendar-event/action/action-calendar-event.component';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-administrator-calendar-component',
  templateUrl: './calendar.component.html'
})
export class CalendarComponent implements OnInit, OnDestroy {
  private subsciption: Subscription;
  private subject = new Subject();
  public events: CalendarEvent[];
  public cEvents: EventInput[] = [];
  public locales = [enLocale];
  public selection: number = null;
  calendarOptions: CalendarOptions = {
    initialView: 'dayGridMonth',
    locale: enLocale,
    eventClick: this.openEventModal.bind(this),
    dateClick: this.changeView.bind(this),
    editable: true,
    dayMaxEvents: true,
    selectable: true,
    select:
      this.openAddFormModal.bind(this),
    headerToolbar: {
      left: 'prev,next today',
      center: 'title',
      right: 'dayGridMonth,timeGridWeek,timeGridDay'
    },
  };
  constructor(
    private calendarService: CalendarEventService,
    private modalService: MatDialog,
    private toast: MatSnackBar,
    private translate: TranslateService,
    private _changeDetectorRef: ChangeDetectorRef
  ) {
    translate.onLangChange.subscribe((event: LangChangeEvent) => {
      if (event.lang == 'pl') {
        this.calendarOptions.locale = plLocale;
      } else {
        this.calendarOptions.locale = enLocale;
      }
      // TODO This as a workaround.
      this._changeDetectorRef.detectChanges();
    });
    if (translate.currentLang == 'pl') {
      this.calendarOptions.locale = plLocale;
    } else {
      this.calendarOptions.locale = enLocale;
    }
  }
  ngOnInit() {
    this.subsciption = timer(0, 30000).pipe(switchMap(() => (this.calendarService.list(this.selection)))).subscribe(result => {
      this.events = (<CalendarEvent[]>result);
      this.cEvents = [];
      for (var i = 0; i < this.events.length; i++) {
        this.cEvents.push({ title: this.events[i].eventName, date: this.events[i].startDate, allDay: this.events[i].allDayEvent, start: this.events[i].startDate, end: this.events[i].endDate, id: this.events[i].eventId + "" })
      }
      this.updateEvents();
    });
  }
  ngOnDestroy() {
    this.subsciption.unsubscribe();
  }
  downloadEvents() {
    setTimeout(() => {
      this.calendarService.list(this.selection).subscribe(result => {
        this.events = (<CalendarEvent[]>result);
        this.cEvents = [];
        for (var i = 0; i < this.events.length; i++) {
          this.cEvents.push({ title: this.events[i].eventName, date: this.events[i].startDate, allDay: this.events[i].allDayEvent, start: this.events[i].startDate, end: this.events[i].endDate, id: this.events[i].eventId + "" })
        }
        this.updateEvents();
      });
    },
      1000);
  }
  //region AddModal
  openAddFormModal(info) {
    if (this.selection) {
      const modalRef = this.modalService.open(CreateCalendarEventComponent, { data: this.selection });
      console.log(info);
      modalRef.componentInstance.startDate = info.start;
      modalRef.componentInstance.endDate = info.end;
      modalRef.componentInstance.allDay = info.allDay;
    } else {
      this.toast.open("Wybierz najpierw kalendarz", 'X', { duration: 2000, panelClass: "bg-warning" });
    }
  }
  //endregion AddModal

  setSelection(id) {
    console.log(id);
    if (!isNaN(Number(id))) {
      this.selection = Number(id);
      this.downloadEvents();
    } else {
      this.selection = null;
      this.downloadEvents();
    }
  }
  openEventModal(info) {
    if (this.selection) {
      if (!isNaN(Number(info.event.id))) {
        const modalRef = this.modalService.open(ActionCalendarEventComponent, { data: info.event.id });
        modalRef.componentInstance.onCloseChildDialog.subscribe(() => { this.downloadEvents() });
      } else {
        this.toast.open("Error", 'X', { duration: 2000, panelClass: "bg-danger" });
      }
    } else {
      this.toast.open("Wybierz najpierw kalendarz", 'X', { duration: 2000, panelClass: "bg-warning" });
    }
  }
  updateEvents() {
    this.calendarOptions.events = this.cEvents;
  }
  changeView() {
    this.calendarOptions.initialView = 'dayGridDay';
  }

}
