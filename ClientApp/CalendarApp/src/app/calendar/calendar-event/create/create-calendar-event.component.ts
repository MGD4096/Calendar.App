import { AfterViewInit, ChangeDetectorRef, Component, Inject, Input, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import * as moment from 'moment';
import { error } from 'selenium-webdriver';
import { CalendarEventService } from '../../../../_services/Calendar/calendar.event.service';
import { CalendarEventFormComponent } from '../form/calendar-event-form.component';


@Component({
  selector: 'create-calendar-event',
  templateUrl: './create-calendar-event.component.html'
})
export class CreateCalendarEventComponent implements AfterViewInit {
  
  @ViewChild('calendarForm') calendarForm: CalendarEventFormComponent;
  @Input() startDate: Date
  @Input() endDate: Date
  @Input() allDay: boolean = false;
  constructor(
    @Inject(MAT_DIALOG_DATA) public data: any,
    private toast: MatSnackBar,
    private calendarEventService: CalendarEventService,
    private dialogRef: MatDialogRef<CreateCalendarEventComponent>,
    private cdr: ChangeDetectorRef
  ) {
    console.log(data);
  }
  ngAfterViewInit() {
    if (this.startDate && this.endDate && this.allDay) {
      this.setStartEnd(this.startDate, this.endDate, this.allDay);
      this.cdr.detectChanges();
    }
  }
  setStartEnd(startDate, endDate,allDay) {
    this.calendarForm.setStartEnd(startDate, endDate);
    //this.calendarForm.setAllDay(allDay);
  }
  AddcalendarEvent() {
    let form = this.calendarForm.getFormData();
    form.append('CalendarId',this.data.toString());
    this.calendarEventService.create(form).subscribe(result => {
      if (result) {
        this.toast.open("Saved", 'X', { duration: 2000, panelClass:"bg-success", });
        this.dialogRef.close();
      } else {
        this.toast.open("Error", 'X', { duration: 2000, panelClass: "bg-danger" });
      }
    }, error => {
        this.toast.open("Error", 'X', { duration: 2000, panelClass: "bg-danger" });
    });

  }
}
