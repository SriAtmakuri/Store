import { Component, OnInit } from '@angular/core';
import { Product } from '../models/product.model';
import { Country } from '../models/country.model';
import { FashionstoreService } from '../services/fashionstore.service';

@Component({
  selector: 'app-fashion-store',
  templateUrl: './fashion-store.component.html',
  styleUrls: ['./fashion-store.component.css']
})
export class FashionStoreComponent implements OnInit {

  public products: Product[] = [];
  public countries:Country[]=[];

  constructor(private fashionService: FashionstoreService) {}

  ngOnInit(): void {
    this.fashionService.getCountries().subscribe((data) => {
      this.countries = data;
    });
    this.fashionService.getProducts().subscribe((data) => {
      this.products = data;
      this.fashionService.getCurrencyExchangeRate("USD")
        .subscribe((rate:any) => {
          this.products.forEach((product) => {
          product.price = (parseInt(product.price) * rate.exchangeRate).toFixed(2);
          product.rateSymbol="USD";
        });
      });
      
    });
  }

  onCountryChange(data:any){
    if(data.target.value){
      this.fashionService.getProducts().subscribe((data) => {
        this.products = data;
      });
      this.fashionService.getCurrencyExchangeRate(data.target.value)
        .subscribe((rate:any) => {
          this.products.forEach((product) => {
          product.price = (parseInt(product.price) * rate.exchangeRate).toFixed(2);
          product.rateSymbol=data.target.value;
        });
    });
  }
  }

}
