import { Injectable } from "@angular/core";
import { IDepartment } from './department.interface';
import { Observable } from "rxjs";
import { HttpClient } from "@angular/common/http";

@Injectable()
export class DepartmentService {
    private readonly apiUrl: string = 'http://localhost:4200/rest/department';

    constructor(private httpClient: HttpClient) {
    }

    public addDepartment(department: IDepartment): Observable<null> {
        return this.httpClient.post<null>(`${this.apiUrl}/create`, department);
    }

    public deleteDepartment(name: string): Observable<object> {
        return this.httpClient.delete(`${this.apiUrl}/${name}/delete`);
    }

    public getDepartments(): Observable<IDepartment[]> {
        return this.httpClient.get<IDepartment[]>(this.apiUrl);
    }

    public updateDepartment(department: IDepartment): Observable<object> {
        return this.httpClient.put(`${this.apiUrl}/update`, department);
    }
}