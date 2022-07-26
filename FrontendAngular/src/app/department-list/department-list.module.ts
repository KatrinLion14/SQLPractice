import { NgModule } from "@angular/core";
import { DepartmentListPageComponent } from "./department-list-page/department-list-page.component";
import { TodoListRoutingModule } from "./department-list-routing.module";
import { MatCardModule } from "@angular/material/card";
import { MatButtonModule } from "@angular/material/button";
import { MatListModule } from "@angular/material/list";
import { CommonModule } from "@angular/common";
import { DepartmentListItemComponent } from "./department-list-item/department-list-item.component";
import { MatIconModule } from "@angular/material/icon";
import { DepartmentService } from "./shared/department.service";
import { HttpClientModule } from "@angular/common/http";
import { ReactiveFormsModule } from "@angular/forms";
import { MatFormFieldModule } from "@angular/material/form-field";
import { MatInputModule } from "@angular/material/input";

@NgModule({
    declarations: [
        DepartmentListPageComponent,
        DepartmentListItemComponent
    ],
    imports: [
        HttpClientModule,
        MatButtonModule,
        MatCardModule,
        MatListModule,
        TodoListRoutingModule,
        CommonModule,
        MatIconModule,
        ReactiveFormsModule,
        MatFormFieldModule,
        MatInputModule
    ],
    providers: [
        DepartmentService
    ]
})
export class DepartmentListModule {
}
