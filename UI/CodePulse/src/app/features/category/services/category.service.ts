import { Injectable } from '@angular/core';
import { AddCategoryRequest } from '../models/add-category-request.model';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {

  //inject http client
  constructor(private http: HttpClient) { }

  //method name , model name 
  addCategory(model: AddCategoryRequest) : Observable<void>
  {
     return this.http.post<void>('https://localhost:44301/api/categories', model)
  }
}
