import { Component, OnDestroy, OnInit } from '@angular/core';
import { Hero } from '../models/hero.model';
import { Subscription } from 'rxjs';
import { HeroService } from '../services/hero.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit, OnDestroy {

  heroes: Hero[] = [];
  private subscription: Subscription = new Subscription();

  constructor(private heroService: HeroService) {}

  ngOnInit() {
    this.getActiveHeroes();
  }

  public getActiveHeroes(): void {

    this.subscription.add(
      this.heroService.getAllActiveHeroes().subscribe({
        next: (data: Hero[]) => this.heroes = data,
        error: (error) => console.log(error)
       })
    )
  }

  public deleteHero(heroId: number): void {
    this.subscription.add(
      this.heroService.deleteHero(heroId).subscribe({
        next: () => this.getActiveHeroes(),
        error: (error) => console.log(error)
      })
    );
  }

  ngOnDestroy(): void {
      this.subscription.unsubscribe();
  }
}
