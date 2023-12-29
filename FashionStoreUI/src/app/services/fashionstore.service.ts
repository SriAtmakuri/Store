import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { Product } from '../models/product.model';
import { Country } from '../models/country.model';

@Injectable({
  providedIn: 'root'
})
export class FashionstoreService {

  private apiUrl = 'https://localhost:7237/api/FashionStore'; // Replace with your actual API endpoint

  constructor(private http: HttpClient) {}

  getProducts(): Observable<Product[]> {
    return this.http.get<Product[]>(this.apiUrl + '/products');
  }
  
  getCountries(): Observable<Country[]> {
    return this.http.get<Country[]>(this.apiUrl + '/countries');
  }
  getCurrencyExchangeRate(currencyCode:any): Observable<any> {
    return this.http.get<Country[]>(this.apiUrl + '/currency/?currencyCode=' + currencyCode);
  }
}

