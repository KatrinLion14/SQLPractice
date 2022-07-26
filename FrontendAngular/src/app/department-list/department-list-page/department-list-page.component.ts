import { Component, OnInit } from '@angular/core';
import { IDepartment } from "../shared/department.interface";
import { DepartmentService } from "../shared/department.service";
import { AbstractControl, FormControl, FormGroup, Validators } from "@angular/forms";

@Component({
    templateUrl: './department-list-page.component.html',
    styleUrls: ['./department-list-page.component.css'],
    providers: [DepartmentService]
})
export class DepartmentListPageComponent implements OnInit {

    public form!: FormGroup;
    public departmentList!: IDepartment[];

    constructor(private departmentService: DepartmentService) {
      this.reloadDepartments();
    }

    public ngOnInit(): void {
        this.form = new FormGroup({
            "name": new FormControl(null, [Validators.required]),
            "office": new FormControl(null, [Validators.required]),
            "address": new FormControl(null, [Validators.required]),
            "phoneNumber": new FormControl(null, [Validators.required])
        });
    }

    private reloadDepartments(): void {
      this.departmentService.getDepartments().subscribe((data:IDepartment[]) => {
          this.departmentList = data;
      })
    }

    public addItem(): void {
        if (this.form.invalid) {
            return;
        }
        this.departmentService.addDepartment({
            name: this.nameControl,
            office: Number(this.officeControl),
            address: this.addressControl,
            phoneNumber: this.phoneNumberControl,
        }).subscribe(() => {
            this.form.controls['name'].setValue(null);
            this.form.controls['address'].setValue(null);
            this.form.controls['office'].setValue(null);
            this.form.controls['phoneNumber'].setValue(null);
            this.form.markAsUntouched();
            this.reloadDepartments();
        });
    }

    public deleteDepartment(department: IDepartment): void {
        this.departmentService.deleteDepartment(department.name!).subscribe(() => {
            this.reloadDepartments();
        });
    }

    public updateDepartment(): void {
        this.departmentService.updateDepartment({
            name: this.nameControl,
            office: Number(this.officeControl),
            address: this.addressControl,
            phoneNumber: this.phoneNumberControl,
        }).subscribe(() => {
            this.form.controls['name'].setValue(null);
            this.form.controls['address'].setValue(null);
            this.form.controls['office'].setValue(null);
            this.form.controls['phoneNumber'].setValue(null);
            this.form.markAsUntouched();
            this.reloadDepartments();
        });
    }

    get nameControl(): string {
        return this.form.controls['name'].value;
    }
    get addressControl(): string {
      return this.form.controls['address'].value;
    }
    get officeControl(): string {
      return this.form.controls['office'].value;
    }
    get phoneNumberControl(): string {
      return this.form.controls['phoneNumber'].value;
    }
}