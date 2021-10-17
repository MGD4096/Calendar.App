import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { AuthorizeGuard } from "../../../api-authorization/authorize.guard";
import { CalendarComponent } from "./calendar/calendar.component";

const routes: Routes = [
  { path: '', component: CalendarComponent, canActivate: [AuthorizeGuard] },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CalendarRoutingModule { }
