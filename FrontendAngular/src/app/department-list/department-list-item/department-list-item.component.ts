import { Component, EventEmitter, Input, Output } from "@angular/core";
import { IDepartment } from "../shared/department.interface";

@Component({
  selector: 'app-department-list-item',
  templateUrl: './department-list-item.component.html',
  styleUrls: ['./department-list-item.component.css']
})

export class DepartmentListItemComponent {
    @Input() public item!: IDepartment;
    @Output() public delete: EventEmitter<IDepartment> = new EventEmitter<IDepartment>();

    public deleteClicked(): void {
        this.delete.emit(this.item);
    }
}