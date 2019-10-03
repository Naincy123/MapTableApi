import {PipeTransform,Pipe} from '@angular/core';

@Pipe({
    name:'studentfilter'
})

export class StudentFilterPipe implements PipeTransform{
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
            console.log(a.StudentName);
            return a.StudentName.toLowerCase().includes(searchText);
        })
    }
}