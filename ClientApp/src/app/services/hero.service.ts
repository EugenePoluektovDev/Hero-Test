import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { Hero } from "../models/hero.model";

@Injectable({
  providedIn: 'root'
})
export class HeroService {
  private apiUrl = 'https://localhost:7014/heroes';

  constructor(private http: HttpClient) {

  }

  public getAllActiveHeroes(): Observable<Hero[]> {
    return this.http.get<Hero[]>(this.apiUrl);
  }

  public deleteHero(heroId: number): Observable<void> {
    return this.http.delete<void>(this.apiUrl + "/" + heroId);
  }

  public addHero(hero: Hero): Observable<void> {
    return this.http.post<void>(this.apiUrl, hero);
  }
}
