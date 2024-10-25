import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Brand } from '../models/brand.model';
import { HeroService } from '../services/hero.service';
import { Subscription } from 'rxjs/internal/Subscription';
import { BrandService } from '../services/brand.service';
import { Router } from '@angular/router';
import { Hero } from '../models/hero.model';

@Component({
  selector: 'app-add-hero',
  templateUrl: './add-hero.component.html'
})
export class AddHeroComponent implements OnInit, OnDestroy {
  heroForm: FormGroup;
  submitted: boolean = false;
  brands: Brand[] = [{
    Id: 1,
    Name: "DC"
  },{
    Id: 2,
    Name: "Marvel"
  }];
  private subscription: Subscription = new Subscription();

  constructor(private fb: FormBuilder, private heroService: HeroService, private brandService: BrandService, private router: Router) {
    this.heroForm = this.fb.group({
      name: ['', [Validators.required, Validators.maxLength(100)]],
      alias: ['', [Validators.required, Validators.maxLength(50)]],
      brandId: ['', Validators.required]
    });
  }

  ngOnInit(): void {
    this.GetActiveBrands();
  }

  public GetActiveBrands(): void {
    this.subscription.add(
      this.brandService.getAllActiveBrands().subscribe({
        next: (brands: Brand[]) => this.brands = brands,
        error: () => this.brands = []
      })
    );
  }

  public addHero(): void {
    this.submitted = true;

    if (this.heroForm.valid) {

      const newHero: Hero = this.heroForm.value;

      this.subscription.add(
        this.heroService.addHero(newHero).subscribe({
          next: () => this.router.navigate(['']),
          error: (error) => console.log(error)
        })
      );
    }
  }

  ngOnDestroy(): void {
      this.subscription.unsubscribe();
  }
}
