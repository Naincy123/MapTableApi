import {PipeTransform,Pipe} from '@angular/core';

@Pipe({
    name:'coursefilter'
})

export class CourseFilterPipe implements PipeTransform{
    transform(items:any[],searchText:string) : any[] {
        if(!items){
            return [];

        }
        if(!searchText){
            return items;
        }
        searchText=searchText.toLowerCase();
        console.log(searchText);
        return items.filter(a=>{
            console.log(a.CourseName);
            return a.CourseName.toLowerCase().includes(searchText);
        })
    }
}