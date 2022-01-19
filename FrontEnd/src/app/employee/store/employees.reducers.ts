import * as employeeActions from './employees.actions';
import {AppAction} from '../../app.action';

import { Employee } from '../employee';
import { createFeatureSelector, createSelector } from '@ngrx/store';


export interface State {
  data: Employee[];
  selected: Employee;
  action: string;
  done: boolean;
  error?: Error;
}

const initialState: State = {
  data: [],
  selected: null,
  action: null,
  done: false,
  error: null
};

export function reducer(state = initialState, action: AppAction): State {
    debugger;
  // ...state create immutable state object
  switch (action.type) {
      /*************************
     * GET all EMPs actions
     ************************/
    case employeeActions.GET_EMPLOYEES:
      return {
        ...state,
        action: employeeActions.GET_EMPLOYEES,
        done: false,
        selected: null,
        error: null
      };
    case employeeActions.GET_EMPLOYEES_SUCCESS:
      return {
        ...state,
        data: action.payload,
        done: true,
        selected: null,
        error: null
      };
    case employeeActions.GET_EMPLOYEES_ERROR:
      return {
        ...state,
        done: true,
        selected: null,
        error: action.payload
      };

      /*************************
     * GET EMP by id actions
     ************************/
    case employeeActions.GET_EMPLOYEE:
      return {
        ...state,
        action: employeeActions.GET_EMPLOYEE,
        done: false,
        selected: null,
        error: null
      };
    case employeeActions.GET_EMPLOYEE_SUCCESS:
      return {
        ...state,
        selected: action.payload,
        done: true,
        error: null
      };
    case employeeActions.GET_EMPLOYEE_ERROR:
      return {
        ...state,
        selected: null,
        done: true,
        error: action.payload
      };

      /*************************
     * CREATE EMP actions
     ************************/
    case employeeActions.CREATE_EMPLOYEE:
      return {
        ...state,
        selected: action.payload,
        action: employeeActions.CREATE_EMPLOYEE,
        done: false,
        error: null
      };
    case employeeActions.CREATE_EMPLOYEE_SUCCESS:
      {
        const newEMP = {
          ...state.selected,
          id: action.payload
        };
        const data = [
          ...state.data,
          newEMP
        ];
        return {
          ...state,
          data,
          selected: null,
          error: null,
          done: true
        };
      }
    case employeeActions.CREATE_EMPLOYEE_ERROR:
      return {
        ...state,
        selected: null,
        done: true,
        error: action.payload
      };

      /*************************
     * UPDATE EMP actions
     ************************/
    case employeeActions.UPDATE_EMPLOYEE:
      return {
        ...state,
        selected: action.payload,
        action: employeeActions.UPDATE_EMPLOYEE,
        done: false,
        error: null
      };
    case employeeActions.UPDATE_EMPLOYEE_SUCCESS:
      {
        // if(state.selected==null)
        // return {
        //   ...state,
        //   ...state.data,
        //   done: true,
        //   selected: null,
        //   error: null
        // };
        const index = state
          .data
          .findIndex(h => h.id === state.selected.id);
      

        if (index >= 0) {
          const data = [
            ...state.data.slice(0, index),
            state.selected,
            ...state.data.slice(index + 1)
          ];
          return {
            ...state,
            data,
            done: true,
            selected: null,
            error: null
          };
        }
        return state;
      }
    case employeeActions.UPDATE_EMPLOYEE_ERROR:
      return {
        ...state,
        done: true,
        selected: null,
        error: action.payload
      };

      /*************************
     * DELETE EMP actions
     ************************/
    case employeeActions.DELETE_EMPLOYEE:
      {
        const selected = state.data.find(h => h.id === action.payload);
        return {
          ...state,
          selected,
          action: employeeActions.DELETE_EMPLOYEE,
          done: false,
          error: null
        };
      }
    case employeeActions.DELETE_EMPLOYEE_SUCCESS:
      {
        const data = state.data.filter(h => h.id !== state.selected.id);
        return {
          ...state,
          data,
          selected: null,
          error: null,
          done: true
        };
      }
    case employeeActions.DELETE_EMPLOYEE_ERROR:
      return {
        ...state,
        selected: null,
        done: true,
        error: action.payload
      };
  }
  return state;
}

/*************************
 * SELECTORS
 ************************/
export const getEmployeesState = createFeatureSelector < State > ('employees');
export const getAllEmployees = createSelector(getEmployeesState, (state: State) => {
  console.log("getAllEmployees reducer called");
  // alert(state.data);
 return state.data;});
export const getEmployee = createSelector(getEmployeesState, (state: State) => {
  if (state.action === employeeActions.GET_EMPLOYEES && state.done) {
    return state.selected;
  } else {
    return null;
  }

});
export const isDeleted = createSelector(getEmployeesState, (state: State) =>
  state.action === employeeActions.DELETE_EMPLOYEE && state.done && !state.error);
export const isCreated = createSelector(getEmployeesState, (state: State) =>
 state.action === employeeActions.CREATE_EMPLOYEE && state.done && !state.error);
export const isUpdated = createSelector(getEmployeesState, (state: State) =>
{
  return (state.action === employeeActions.UPDATE_EMPLOYEE && state.done && !state.error);});

export const getDeleteError = createSelector(getEmployeesState, (state: State) => {
  return state.action === employeeActions.DELETE_EMPLOYEE
    ? state.error
   : null;
});
export const getCreateError = createSelector(getEmployeesState, (state: State) => {
  return state.action === employeeActions.CREATE_EMPLOYEE
    ? state.error
   : null;
});
export const getUpdateError = createSelector(getEmployeesState, (state: State) => {
  return state.action === employeeActions.UPDATE_EMPLOYEE
    ? state.error
   : null;
});
export const getEmployeesError = createSelector(getEmployeesState, (state: State) => {
  return state.action === employeeActions.GET_EMPLOYEES
    ? state.error
   : null;
});
export const getEmployeeError = createSelector(getEmployeesState, (state: State) => {
  return state.action === employeeActions.GET_EMPLOYEES
    ? state.error
   : null;
});
