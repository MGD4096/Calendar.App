import { AfterViewInit, ChangeDetectorRef, Component, Inject, Input, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import * as moment from 'moment';
import { error } from 'selenium-webdriver';
import { CalendarEventService } from '../../../../_services/Calendar/calendar.event.service';


@Component({
  selector: 'delete-calendar-event',
  templateUrl: './delete-calendar-event.component.html'
})
export class DeleteCalendarEventComponent  {
  constructor(
    @Inject(MAT_DIALOG_DATA) public data: any,
    private toast: MatSnackBar,
    private calendarEventService: CalendarEventService,
    private dialogRef: MatDialogRef<DeleteCalendarEventComponent>,
  ) {

  }
  
  DeleteCalendarEvent() {
    this.calendarEventService.delete(this.data).subscribe(result => {
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
