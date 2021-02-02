import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Model, Product } from './Model';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

baseUrl:string="http://localhost:5000/";
  model=new Model();

  constructor(private http: HttpClient) { }

  getProducts():Observable<Product[]>{

 return this.http.get<Product[]>(this.baseUrl+'api/products');


    }

    addProduct(product:Product):Observable<Product>{

      return this.http.post<Product>(this.baseUrl+'api/products',product);

    }

   updateProduct(product:Product){

    return this.http.put<Product>(this.baseUrl+'api/products/'+product.productid,product);
   }

   deleteProduct(product:Product):Observable<Product>
  {

    return this.http.delete<Product>(this.baseUrl+'api/products/'+product.productid);
  }



    getProductById(id:number){

      return this.model.products.find(i=>i.productid==id);
    }



  saveProduct(product:Product){

   if(product.productid==0)
   {


    this.model.products.push(product);

   }
else{

 const p=this.getProductById(product.productid);
 p.name=product.name;
 p.price=product.price;
 p.isActive=product.isActive;
}


  }


}
