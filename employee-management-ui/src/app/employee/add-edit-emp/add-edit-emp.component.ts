import { Component, Input, OnInit } from '@angular/core';
import { SharedService } from 'src/app/shared.service';

@Component({
  selector: 'app-add-edit-emp',
  templateUrl: './add-edit-emp.component.html',
  styleUrls: ['./add-edit-emp.component.css']
})
export class AddEditEmpComponent implements OnInit {

  constructor(private service:SharedService) { }
  @Input() emp:any;
  EmployeeId:string = "";
  EmployeeName:string = "";
  Department:string = "";
  DateOfJoining:string = "";
  PhotoFileName:string = "";
  PhotoFilePath:string = "";

  DepartmentsList:any=[]; // for department list dropdown

  ngOnInit(): void {
    this.loadDepartmentList();
  }

  loadDepartmentList() {
    this.service.getAllDepartmentNames().subscribe((data:any)=>{
      this.DepartmentsList = data;
      this.EmployeeId = this.emp.EmployeeId;
      this.EmployeeName = this.emp.EmployeeName;
      this.Department = this.emp.Department;
      this.DateOfJoining = this.emp.DateOfJoining;
      this.PhotoFileName = this.emp.PhotoFileName;
      this.PhotoFilePath = this.service.PhotoUrl + this.PhotoFileName;
    });
  }

  addDepartment() {
    var val = {DepartmentId: this.DepartmentId,
               DepartmentName: this.DepartmentName};
    this.service.addDepartment(val).subscribe(res=>{
      alert(res.toString());
    });
  }

  updateDepartment() {
    var val = {DepartmentId: this.DepartmentId,
               DepartmentName: this.DepartmentName};
    this.service.updateDepartment(val).subscribe(res=>{
      alert(res.toString());
    });
  }

}

