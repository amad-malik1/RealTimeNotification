import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { EmployeeListComponent } from './employee/employee-list/employee-list.component';
import { EmployeeEditComponent } from './employee/employee-edit/employee-edit.component';
import { EmployeeDetailComponent } from './employee/employee-detail/employee-detail.component';
import { ModalComponent } from './modal/modal.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
 import { EmployeeEffects } from './employee/store/employees.effects';
 import * as employeesReducer from './employee/store/employees.reducers';
 import { ActionReducerMap } from '@ngrx/store/src/models';
 import { StoreModule } from '@ngrx/store';
import { EffectsModule } from '@ngrx/effects';
import { EmployeeService } from './employee/employee.service';

 export const reducers: ActionReducerMap<any> = {
  employees: employeesReducer.reducer
};
@NgModule({
  declarations: [
    AppComponent,
    EmployeeListComponent,
    EmployeeEditComponent,
    EmployeeDetailComponent,
    ModalComponent,
    NavMenuComponent,
    HomeComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,  
    FormsModule,  
    HttpClientModule,  
    StoreModule.forRoot(reducers),
    EffectsModule.forRoot([EmployeeEffects])
  ],
  providers: [
    EmployeeService, 
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
