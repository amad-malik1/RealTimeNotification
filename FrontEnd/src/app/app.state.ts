import * as fromEmployeess from './employee/store/employees.reducers';

export interface AppState {
    employees: fromEmployeess.State;
}
