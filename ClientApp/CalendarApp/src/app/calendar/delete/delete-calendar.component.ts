import { AfterViewInit, ChangeDetectorRef, Component, Inject, Input, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import * as moment from 'moment';
import { error } from 'selenium-webdriver';
import { CalendarService } from '../../../_services/Calendar/calendar.service';


@Component({
  selector: 'delete-calendar',
  templateUrl: './delete-calendar.component.html'
})
export class DeleteCalendarComponent  {
  constructor(
    @Inject(MAT_DIALOG_DATA) public data: any,
    private toast: MatSnackBar,
    private calendarService: CalendarService,
    private dialogRef: MatDialogRef<DeleteCalendarComponent>,
  ) {

  }
  
  DeleteCalendar() {
    this.calendarService.delete(this.data).subscribe(result => {
      if (result) {
        this.toast.open("Deleted", 'X', { duration: 2000, panelClass: "bg-success", });
        this.dialogRef.close();
      } else {
        this.toast.open("Error", 'X', { duration: 2000, panelClass: "bg-danger" });
      }
    }, error => {
      this.toast.open("Error", 'X', { duration: 2000, panelClass: "bg-danger" });
    });

  }
}
