import {Action} from '@ngrx/store';
import { Employee } from '../employee';

export const GET_EMPLOYEES = '[ALL] Employees';
export const GET_EMPLOYEES_SUCCESS = '[ALL] Employees Success';
export const GET_EMPLOYEES_ERROR = '[ALL] Employees Error';

export const GET_EMPLOYEE = '[GET] Employee';
export const GET_EMPLOYEE_SUCCESS = '[GET] Employees Success';
export const GET_EMPLOYEE_ERROR = '[GET] Employees Error';

export const CREATE_EMPLOYEE = '[CREATE] Employee';
export const CREATE_EMPLOYEE_SUCCESS = '[CREATE] Employee Success';
export const CREATE_EMPLOYEE_ERROR = '[CREATE] Employee Error';

export const DELETE_EMPLOYEE = '[DELETE] Employee';
export const DELETE_EMPLOYEE_SUCCESS = '[DELETE] Employee Success';
export const DELETE_EMPLOYEE_ERROR = '[DELETE] Employee Error';

export const UPDATE_EMPLOYEE = '[UPDATE] Employee';
export const UPDATE_EMPLOYEE_SUCCESS = '[UPDATE] Employee Success';
export const UPDATE_EMPLOYEE_ERROR = '[UPDATE] Employee Error';

/****************************************
 * GET all the Employees
 ****************************************/
export class GetAllEmployees implements Action {
  readonly type = GET_EMPLOYEES;
}

export class GetAllEmployeesSuccess implements Action {
  readonly type = GET_EMPLOYEES_SUCCESS;

  constructor(public payload: Employee[]) {
  }
}

export class GetAllEmployeesError implements Action {
  readonly type = GET_EMPLOYEES_ERROR;

  constructor(public payload: Error) {
  }
}

/****************************************
 * GET Employee by id
 ****************************************/
export class GetEmployee implements Action {
  readonly type = GET_EMPLOYEE;

  constructor(public payload: number) {
  }
}

export class GetEmployeeSuccess implements Action {
  readonly type = GET_EMPLOYEE_SUCCESS;

  constructor(public payload: Employee) {
  }
}

export class GetEmployeeError implements Action {
  readonly type = GET_EMPLOYEE_ERROR;

  constructor(public payload: Error) {
  }
}

/****************************************
 * ADD new Employee
 ****************************************/
export class AddEmployee implements Action {
  readonly type = CREATE_EMPLOYEE;

  constructor(public payload: Employee) {
  }
}

export class AddEmployeeSuccess implements Action {
  readonly type = CREATE_EMPLOYEE_SUCCESS;

  constructor(public payload: number) {
  }
}

export class AddEmployeeError implements Action {
  readonly type = CREATE_EMPLOYEE_ERROR;

  constructor(public payload: Error) {
  }
}

/****************************************
 * REMOVE a Employee by id
 ****************************************/
export class RemoveEmployee implements Action {
  readonly type = DELETE_EMPLOYEE;

  constructor(public payload: number) {
  }
}

export class RemoveEmployeeSuccess implements Action {
  readonly type = DELETE_EMPLOYEE_SUCCESS;

  constructor(public payload: Employee) {
  }
}

export class RemoveEmployeeError implements Action {
  readonly type = DELETE_EMPLOYEE_ERROR;

  constructor(public payload: Error) {
  }
}

/****************************************
 * UPDATE Employee by id
 ****************************************/
export class UpdateEmployee implements Action {
  readonly type = UPDATE_EMPLOYEE;

  constructor(public payload: Employee) {
  }
}

export class UpdateEmployeeSuccess implements Action {
  readonly type = UPDATE_EMPLOYEE_SUCCESS;
}

export class UpdateEmployeeError implements Action {
  readonly type = UPDATE_EMPLOYEE_ERROR;

  constructor(public payload: Error) {
  }
}
