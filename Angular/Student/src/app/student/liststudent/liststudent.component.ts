import { Component, OnInit } from '@angular/core';
import { StudentService } from '../student.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-liststudent',
  templateUrl: './liststudent.component.html',
  styleUrls: ['./liststudent.component.css']
})
export class ListstudentComponent implements OnInit {
  title="Students";
  students: any;
  searchText='';

  constructor(private ps : StudentService, private router: Router) { }

  ngOnInit() {
    this.getStudents();
  }
  getStudents(){
    this.ps.getStudents().subscribe(data =>{
      this.students=data;
    });
  }
  idtofetch=1;
  getStudentById(){
    
    this.ps.getStudentById(this.idtofetch).subscribe(data => {
      this.students=data;
    });
  }
  details(id):void{
    this.router.navigate(['listdetails',id]);
  }
}
