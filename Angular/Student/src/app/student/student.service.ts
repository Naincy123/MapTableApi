import { Injectable } from '@angular/core';
import { HttpClient,HttpHeaders } from '@angular/common/http';
import { throwError, Observable } from 'rxjs';
import { student } from './entities/student';
import {tap,catchError,map} from 'rxjs/operators';
import { course } from './entities/course';
import { studentcourse } from './entities/studentcourse';

@Injectable()
export class StudentService {
  apiurl='http://localhost:64663/api/students';
  apiurl1='http://localhost:64663/api/courses';
  apiurl2='http://localhost:64663/api/studentcourses';
  
  headers= new HttpHeaders().set('Content-Type', 'application/json').set('Accept','application/json');
  httpOptions={
    headers : this.headers
  };

  constructor(private http: HttpClient) { }
  private handleError(error: any){
    console.error(error);
    return throwError(error);
  }
  getStudents(): Observable<student[]>{
    return this.http.get<student[]>(this.apiurl).pipe(
      tap(data => console.log(data)),
      catchError(this.handleError)
    );
  }
  getStudentById(id: number): Observable<student>{
    const myurl =`${this.apiurl}/${id}`;
    return this.http.get<student>(myurl).pipe(
      catchError(this.handleError)
    );
  }
  getCourses(): Observable<course[]>{
    return this.http.get<course[]>(this.apiurl1).pipe(
      tap(data => console.log(data)),
      catchError(this.handleError)
    );
  }
  getCourseById(id: number): Observable<course>{
    const myurl =`${this.apiurl1}/${id}`;
    return this.http.get<course>(myurl).pipe(
      catchError(this.handleError)
    );
  }
  getStudentCourses(): Observable<studentcourse[]>{
    return this.http.get<studentcourse[]>(this.apiurl2).pipe(
      tap(data => console.log(data)),
      catchError(this.handleError)
    );
  }
  getStudentCourseById(id: number): Observable<studentcourse>{
    const myurl =`${this.apiurl2}/${id}`;
    return this.http.get<studentcourse>(myurl).pipe(
      catchError(this.handleError)
    );
  }
}
