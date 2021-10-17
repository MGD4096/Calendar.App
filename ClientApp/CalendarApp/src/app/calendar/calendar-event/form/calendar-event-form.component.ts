import { Component, Input, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import * as moment from 'moment';
import { CalendarEvent } from '../../../../_models/Calendar/calendar.event';


@Component({
  selector: 'calendar-event-form',
  styleUrls:['./calendar-event-form.component.scss'],
  templateUrl: './calendar-event-form.component.html'
})
export class CalendarEventFormComponent implements OnInit {
  @Input() id: number;
  public myForm: FormGroup;
  public sendNotification: boolean = false;
  public allDay: boolean = false;
  constructor(
    private formBuilder: FormBuilder
  ) {

  }
  ngOnInit() {
    this.buildForm();
  }
  setStartEnd(startDate,endDate) {
    this.myForm.get('startTime').setValue(moment(startDate).format('HH:mm'))
    this.myForm.get('startDate').setValue(startDate)
    this.myForm.get('endTime').setValue(moment(endDate).format('HH:mm'))
    this.myForm.get('endDate').setValue(endDate)
  }
  setAllDay(allDay) {
    if (allDay) {
      this.allDay = allDay;
      this.myForm.get('allDayEvent').setValue(allDay)
      this.hideEndDate(allDay);
    } else {
      this.allDay = allDay;
      this.myForm.get('allDayEvent').setValue(allDay);
      this.hideEndDate(allDay);
    }
  }
  setForm(event: CalendarEvent) {
    const { eventId, ...formData } = event;
    this.myForm.patchValue(formData);
    this.myForm.get('startTime').setValue(moment(event.startDate).format('HH:mm'))
    this.myForm.get('startDate').setValue(event.startDate)
    this.myForm.get('endTime').setValue(moment(event.endDate).format('HH:mm'))
    this.myForm.get('endDate').setValue(event.endDate)
    this.myForm.get('type').setValue(event.eventType)
    this.allDay = event.allDayEvent;
    this.sendNotification = !((event.notifyBefore == null && event.notifyMethod == null));
    this.hideNotificationField(!this.sendNotification);
    this.hideEndDate(event.allDayEvent);
    this.myForm.get('allDayEvent').setValue(event.allDayEvent)

    if (event.notifyMethod != null && event.notifyMethod != '') {
      this.myForm.get('notificationMethod').setValue(event.notifyMethod.split(','));
    } else {
      this.myForm.get('notificationMethod').setValue([]);
    }
    if (event.notifyBefore != null) {
      let timeBefore = event.notifyBefore.hours + ":" + event.notifyBefore.minutes;
      this.myForm.get('notificationBefore').setValue(timeBefore);
    } else {
      this.myForm.get('notificationBefore').setValue("00:00");
    }
  }
  private buildForm() {
    this.myForm = this.formBuilder.group({
      notificationBefore: ['00:00'],
      notificationMethod: [''],
      type: [null, Validators.required],
      eventDescription: '',
      eventName: [null, Validators.required],
      startDate: [moment().format('MM/DD/YYYY'), Validators.required],
      startTime: [null],
      endDate: [''],
      endTime: [null],
      allDayEvent: ['false'],

      //photo: [null, Validators.required]
    });
  }
  getFormData() {
    var formData = new FormData();
    formData.append("eventType", this.myForm.get('type').value);
    formData.append("eventName", this.myForm.get('eventName').value);
    formData.append("eventDescription", this.myForm.get('eventDescription').value);
    formData.append("notifyMethod", this.myForm.get('notificationMethod').value);
    formData.append("notifyBefore", this.myForm.get('notificationBefore').value);
    formData.append("allDayEvent", this.myForm.get('allDayEvent').value);
    formData.append("startDate", moment(this.myForm.get('startDate').value).format('YYYY.MM.DD') + " " + this.myForm.get('startTime').value);
    formData.append("endDate", (this.myForm.get('endDate').value != null && this.myForm.get('endDate').value != '') ? moment(this.myForm.get('endDate').value).format('YYYY.MM.DD') + " " + this.myForm.get('endTime').value : moment(this.myForm.get('startDate').value).format('YYYY.MM.DD'));
    return formData;
  }
  //Gui Manipulation, bad practice
  hideNotificationField(flag: boolean) {
    if (flag) {
      document.getElementById("notification-group").classList.add("d-none");
      this.myForm.get('notificationMethod').setValue(null);
      this.myForm.get('notificationBefore').setValue("00:00");
    } else {
      document.getElementById("notification-group").classList.remove("d-none");
    }
  }
  hideEndDate(flag: boolean) {
    if (flag) {
      document.getElementById("endDate").classList.add("d-none");
      this.myForm.get('endDate').setValue(null);
    } else {
      document.getElementById("endDate").classList.remove("d-none");
    }
  }
  //end Gui Manipulation
}
