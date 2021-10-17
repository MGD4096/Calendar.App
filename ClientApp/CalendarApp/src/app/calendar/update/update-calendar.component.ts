import { Component, Inject, Input, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import * as moment from 'moment';
import { error } from 'selenium-webdriver';
import { CalendarService } from '../../../_services/Calendar/calendar.service';
import { CalendarFormComponent } from '../form/calendar-form.component';


@Component({
  selector: 'update-calendar',
  templateUrl: './update-calendar.component.html'
})
export class UpdateCalendarComponent implements OnInit {
  @ViewChild('calendarForm') calendarForm: CalendarFormComponent;

  constructor(
    @Inject(MAT_DIALOG_DATA) public data: any,
    private toast: MatSnackBar,
    private calendarService: CalendarService,
    private dialogRef: MatDialogRef<UpdateCalendarComponent>
  ) {

  }
  ngOnInit() {
    this.calendarService.get(this.data).subscribe(result => {
      this.calendarForm.setForm(result);
    },
      error => {
        this.toast.open("Error", 'X', { duration: 2000, panelClass: "bg-danger" });
      });
  }
  ParseDate() {

  }
  UpdateCalendar() {
    const formData = this.calendarForm.getFormData();
    formData.append('calendarId', this.data.toString());
    this.calendarService.update(formData).subscribe(result => {
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
