import { Injectable } from '@angular/core';
import { AddCategoryRequest } from '../models/add-category-request.model';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Category } from '../models/category.model';

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

  //as it is a get method, reuqest object is not necessary it just returns the 
  //observable of type category list
  getAllCategories(): Observable<Category[]>{
    return this.http.get<Category[]>('https://localhost:44301/api/categories');
  }
}
