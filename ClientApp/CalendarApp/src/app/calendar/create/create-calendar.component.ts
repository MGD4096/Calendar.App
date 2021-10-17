import { AfterViewInit, ChangeDetectorRef, Component, Input, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import * as moment from 'moment';
import { error } from 'selenium-webdriver';
import { CalendarService } from '../../../_services/Calendar/calendar.service';
import { CalendarFormComponent } from '../form/calendar-form.component';


@Component({
  selector: 'create-calendar',
  templateUrl: './create-calendar.component.html'
})
export class CreateCalendarComponent implements AfterViewInit {
  @ViewChild('calendarForm') calendarForm: CalendarFormComponent;
  constructor(
    private toast: MatSnackBar,
    private calendarService: CalendarService,
    private dialogRef: MatDialogRef<CreateCalendarComponent>,
    private cdr: ChangeDetectorRef
  ) {
    
  }
  ngAfterViewInit() {
 
  }
  
  Addcalendar() {
    this.calendarService.create(this.calendarForm.getFormData()).subscribe(result => {
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
