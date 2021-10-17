import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { NgxSummernoteModule } from 'ngx-summernote';
import { SharedModule } from '../../_shared/shared.module';
import { FileSaverModule } from 'ngx-filesaver';
import { CalendarComponent } from './calendar/calendar.component';
import { FullCalendarModule } from '@fullcalendar/angular';
import dayGridPlugin from '@fullcalendar/daygrid'; // a plugin
import listPligin from '@fullcalendar/list'; // a plugin
import timeGridPlugin from '@fullcalendar/timegrid';
import interactionPlugin from '@fullcalendar/interaction'; // a plugin
import { WidgetCalendarComponent } from './widget/widget-calendar.component';
import { MatIconModule } from '@angular/material/icon';
import { DeleteCalendarEventComponent } from './calendar-event/delete/delete-calendar-event.component';
import { CreateCalendarEventComponent } from './calendar-event/create/create-calendar-event.component';
import { UpdateCalendarEventComponent } from './calendar-event/update/update-calendar-event.component';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { CalendarRoutingModule } from './calendar-route.module';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { MatButtonModule } from '@angular/material/button';
import { MatDialogModule } from '@angular/material/dialog';
import { CalendarEventFormComponent } from './calendar-event/form/calendar-event-form.component';
import { ActionCalendarEventComponent } from './calendar-event/action/action-calendar-event.component';
import { MatTableModule } from '@angular/material/table';
import { CalendarListComponent } from './calendar-list/calendar-list.component';
import { MatPaginatorModule } from '@angular/material/paginator';
import { UpdateCalendarComponent } from './update/update-calendar.component';
import { CreateCalendarComponent } from './create/create-calendar.component';
import { DeleteCalendarComponent } from './delete/delete-calendar.component';
import { CalendarFormComponent } from './form/calendar-form.component';
FullCalendarModule.registerPlugins([ // register FullCalendar plugins
  dayGridPlugin,
  listPligin,
  timeGridPlugin,
  interactionPlugin,

]);

@NgModule({
  imports: [
    CommonModule,
    CalendarRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    NgxSummernoteModule,
    SharedModule,
    FileSaverModule,
    FullCalendarModule,
    MatIconModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MatTableModule,
    MatPaginatorModule,
    MatInputModule,
    MatSelectModule,
    MatCheckboxModule,
    MatSnackBarModule,
    MatButtonModule,
    MatDialogModule
  ],
  declarations: [
    CalendarComponent,
    CalendarListComponent,
    CalendarEventFormComponent,
    CalendarFormComponent,
    DeleteCalendarEventComponent,
    CreateCalendarEventComponent,
    UpdateCalendarEventComponent,
    ActionCalendarEventComponent,
    DeleteCalendarComponent,
    CreateCalendarComponent,
    UpdateCalendarComponent
  ],
  entryComponents: [
    DeleteCalendarEventComponent,
    CreateCalendarEventComponent,
    UpdateCalendarEventComponent,
    ActionCalendarEventComponent,
    DeleteCalendarComponent,
    CreateCalendarComponent,
    UpdateCalendarComponent
  ],
  exports: [
    CalendarComponent,
    CalendarEventFormComponent
  ],
})
export class CalendarModule { }
