import { Injectable } from '@angular/core';
import * as employeeActions from './employees.actions';
import {
  AddEmployee,
  AddEmployeeError,
  AddEmployeeSuccess,
  GetAllEmployeesError,
  GetAllEmployeesSuccess,
  GetEmployee,
  GetEmployeeError,
  GetEmployeeSuccess,
  RemoveEmployee,
  RemoveEmployeeError,
  RemoveEmployeeSuccess,
  UpdateEmployee,
  UpdateEmployeeError,
  UpdateEmployeeSuccess,
} from './employees.actions';
import { Observable } from 'rxjs';
import { catchError, map, switchMap } from 'rxjs/operators';
import { Employee } from '../employee';
import { EmployeeService } from '../employee.service';
import { Actions, Effect, ofType } from '@ngrx/effects';
import { Action } from '@ngrx/store';

@Injectable()
export class EmployeeEffects {
  constructor(private actions$: Actions, private svc: EmployeeService) {debugger;}

  @Effect()
  getAllEmployees$: Observable<Action> = this.actions$.pipe(
    ofType(employeeActions.GET_EMPLOYEES),
    switchMap(() => this.svc.getEmployees()),
    map((emps) => new GetAllEmployeesSuccess(emps)),
    catchError((err) => [new GetAllEmployeesError(err)])
  );

  @Effect()
  getEmployee$ = this.actions$.pipe(
    ofType(employeeActions.GET_EMPLOYEES),
    map((action: GetEmployee) => action.payload),
    switchMap((id) => this.svc.getEmployee(id)),
    map((emp) => new GetEmployeeSuccess(emp)),
    catchError((err) => [new GetEmployeeError(err)])
  );

  @Effect()
  updateEmployee$ = this.actions$.pipe(
    ofType(employeeActions.UPDATE_EMPLOYEE),
    map((action: UpdateEmployee) => action.payload),
    switchMap((emp) => this.svc.updateEmployee(emp)),
    map(() => new UpdateEmployeeSuccess()),
    catchError((err) => [new UpdateEmployeeError(err)])
  );

  @Effect()
  createEmployee$ = this.actions$.pipe(
    ofType(employeeActions.CREATE_EMPLOYEE),
    map((action: AddEmployee) => action.payload),
    switchMap((newGame) => this.svc.createEmployee(newGame)),
    map((response) => new AddEmployeeSuccess(response.id)),
    catchError((err) => [new AddEmployeeError(err)])
  );

  @Effect()
  removeEmployee$ = this.actions$.pipe(
    ofType(employeeActions.DELETE_EMPLOYEE),
    map((action: RemoveEmployee) => action.payload),
    // switchMap((id) => this.svc.deleteEmployee(id)),
    // map((hero: Employee) => new RemoveEmployeeSuccess(hero)),
    catchError((err) => [new RemoveEmployeeError(err)])
  );
}
