export class Model {

products:Array<Product>;


constructor() {


  this.products=[
//new Product(1,"popkek",2,true),
//new Product(2,"Biskrem",2.50,false),
//new Product(3,"Coca Cola 2.5 lt",9,true),
//new Product(4,"Albeni",2,false),
//new Product(5,"Halley 10'lu",6,true)
  ];
}
}

export class Product{
productid:number;
name:string;
price:number;
isActive:boolean;

/**
 *
 */
constructor(productid:number,name:string,price:number,isActive:boolean) {
  this.productid=productid;
  this.name=name;
  this.price=price;
  this.isActive=isActive;

}

}
