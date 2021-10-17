import { Component, Input, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import * as moment from 'moment';
import { Calendar } from '../../../_models/Calendar/calendar';


@Component({
  selector: 'calendar-form',
  styleUrls:['./calendar-form.component.scss'],
  templateUrl: './calendar-form.component.html'
})
export class CalendarFormComponent implements OnInit {
  @Input() id: number;
  public myForm: FormGroup;
  constructor(
    private formBuilder: FormBuilder
  ) {

  }
  ngOnInit() {
    this.buildForm();
  }

  setForm(event: Calendar) {
    const { CalendarId, ...formData } = event;
    this.myForm.patchValue(formData);
  
  }
  private buildForm() {
    this.myForm = this.formBuilder.group({
      calendarName: ['', Validators.required],
      calendarDescription: '',
    });
  }
  getFormData() {
    var formData = new FormData();
    formData.append("calendarName", this.myForm.get('calendarName').value);
    formData.append("calendarDescription", this.myForm.get('calendarDescription').value);
    return formData;
  }

}
