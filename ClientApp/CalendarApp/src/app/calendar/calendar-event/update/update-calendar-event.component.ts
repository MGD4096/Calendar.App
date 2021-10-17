import { Component, Inject, Input, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import * as moment from 'moment';
import { error } from 'selenium-webdriver';
import { CalendarEventService } from '../../../../_services/Calendar/calendar.event.service';
import { CalendarEventFormComponent } from '../form/calendar-event-form.component';


@Component({
  selector: 'update-calendar-event',
  templateUrl: './update-calendar-event.component.html'
})
export class UpdateCalendarEventComponent implements OnInit {
  @ViewChild('calendarForm') calendarForm: CalendarEventFormComponent;

  constructor(
    @Inject(MAT_DIALOG_DATA) public data: any,
    private toast: MatSnackBar,
    private calendarEventService: CalendarEventService,
    private dialogRef: MatDialogRef<UpdateCalendarEventComponent>
  ) {

  }
  ngOnInit() {
    this.calendarEventService.get(this.data).subscribe(result => {
      this.calendarForm.setForm(result);
    },
      error => {
        this.toast.open("Error", 'X', { duration: 2000, panelClass: "bg-danger" });
      });
  }
  ParseDate() {

  }
  UpdateCalendarEvent() {
    const formData = this.calendarForm.getFormData();
    formData.append('eventId', this.data.toString());
    this.calendarEventService.update(formData).subscribe(result => {
      if (result) {
        this.toast.open("Saved", 'X', { duration: 2000, panelClass: "bg-success", });
        this.dialogRef.close();
      } else {
        this.toast.open("Error", 'X', { duration: 2000, panelClass: "bg-danger" });
      }
    }, error => {
      this.toast.open("Error", 'X', { duration: 2000, panelClass: "bg-danger" });
    });

  }
}
