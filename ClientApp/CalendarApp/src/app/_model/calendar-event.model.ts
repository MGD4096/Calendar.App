import { Time } from "@angular/common";

export class CalendarEvent {
  EventId: string;
  EventName: string;
  EventDescription: string;
  StartDate: Date;
  EndDate: Date;
  AllDayEvent: boolean;
}
export class CalendarEventDetails extends CalendarEvent {
  NotifyBefore: Time;
  IsRemoved: boolean;
  CalendarId: string;
  Owner: string;
  CreateDate: Date;
  UpdateDate: Date;
}
