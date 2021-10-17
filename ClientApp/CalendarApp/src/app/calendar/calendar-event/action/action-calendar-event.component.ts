import { AfterViewInit, ChangeDetectorRef, Component, EventEmitter, Inject, Input, OnInit, Output, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import * as moment from 'moment';
import { error } from 'selenium-webdriver';
import { DeleteCalendarEventComponent } from '../delete/delete-calendar-event.component';
import { UpdateCalendarEventComponent } from '../update/update-calendar-event.component';

@Component({
  selector: 'action-calendar-event',
  templateUrl: './action-calendar-event.component.html'
})
export class ActionCalendarEventComponent  {
  @Input() onCloseChildDialog = new EventEmitter();

  constructor(
    @Inject(MAT_DIALOG_DATA) public data: any,
    private toast: MatSnackBar,
    private modalService: MatDialog,
    private dialogRef: MatDialogRef<ActionCalendarEventComponent>,
  ) {
  }
  ngOnInit(){
}
  ActionCalendarEvent(actionType:string) {
    if (actionType == "EDIT") {
      this.dialogRef.close(false);
      this.openEditFormModal();
    } else if (actionType == "DELETE") {
      this.dialogRef.close(false);
      this.openDeleteFormModal();
    } else {
      this.toast.open("Error", 'X', { duration: 2000, panelClass: "bg-danger" });
    }
  }
  openEditFormModal() {
    const modalRef = this.modalService.open(UpdateCalendarEventComponent, { data: this.data });
    modalRef.afterClosed().subscribe(() => { this.onCloseChildDialog.emit() });
  }
  openDeleteFormModal() {
    const modalRef = this.modalService.open(DeleteCalendarEventComponent, { data: this.data });
    modalRef.afterClosed().subscribe(() => { this.onCloseChildDialog.emit() });
  }
}
