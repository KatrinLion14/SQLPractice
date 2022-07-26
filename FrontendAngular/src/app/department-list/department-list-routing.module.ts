import { RouterModule, Routes } from "@angular/router";
import { NgModule } from "@angular/core";
import { DepartmentListPageComponent } from "./department-list-page/department-list-page.component";

const routes: Routes = [
    {
        path: 'department-list',
        component: DepartmentListPageComponent
    }
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class TodoListRoutingModule { }