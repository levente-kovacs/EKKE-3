import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { Flower } from '../model/flower';

@Injectable({
  providedIn: 'root'
})
export class FlowerService {

  apiUrl = environment.apiUrl;

  constructor(
    private http: HttpClient
  ) { }

  getAll(): Observable<Flower[]> {
    return this.http.get<Flower[]>(`${this.apiUrl}flowers`);
  }

  getOne(id: string): Observable<Flower> {
    return this.http.get<Flower>(`${this.apiUrl}flowers/${id}`);
  }

  createFlower(flower: Flower): Observable<Flower> {
    return this.http.post<Flower>(`${this.apiUrl}flowers`, flower);
  }

  updateFlower(id: string, flower: Flower): Observable<Flower> {
    return this.http.put<Flower>(`${this.apiUrl}flowers/${id}`, flower);
  }

  deleteFlower(id: string): Observable<{ message: string }> {
    return this.http.delete<{ message: string }>(`${this.apiUrl}flowers/${id}`);
  }

  searchByName(word: string): Observable<Flower[]> {
    return this.http.get<Flower[]>(`${this.apiUrl}flowers/search/${word}`);
  }

  getFlowersForSummerAutumn(): Observable<{ month: number; name: string }[]> {
    return this.http.get<{ month: number; name: string }[]>(`${this.apiUrl}flowers/spec/summer-autumn`);
  }

  getMostCommonMeaning(): Observable<{ meaning: string; count: number }> {
    return this.http.get<{ meaning: string; count: number }>(
      `${this.apiUrl}flowers/spec/most-common-meaning`
    );
  }
}
