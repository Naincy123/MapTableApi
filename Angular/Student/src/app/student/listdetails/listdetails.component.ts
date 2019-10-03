import { Component, OnInit } from '@angular/core';
import { StudentService } from '../student.service';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-listdetails',
  templateUrl: './listdetails.component.html',
  styleUrls: ['./listdetails.component.css']
})
export class ListdetailsComponent implements OnInit {
  title="Studentcourses";
  studentid:any;
  studentcourses;
  constructor(private route :ActivatedRoute,private ps:StudentService,private router:Router) { 
    this.route.params.subscribe((data)=>{
      this.studentid=data.id;
    })
    this.ps.getStudentCourseById(this.studentid).subscribe(data=>{
      this.studentcourses=data;
     
    })
  }

  ngOnInit() {
  }

}
