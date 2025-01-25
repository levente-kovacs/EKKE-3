import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { RouterModule } from '@angular/router';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { Flower } from '../../model/flower';
import { FlowerService } from '../../service/flower.service';

@Component({
  selector: 'app-queries',
  standalone: true,
  imports: [
    FormsModule,
    CommonModule,
    FontAwesomeModule,
    MatButtonModule,
    RouterModule
  ],
  templateUrl: './queries.component.html',
  styleUrl: './queries.component.scss'
})
export class QueriesComponent {

  searchWord: string = '';
  flowers: Flower[] = [];
  summerAutumnFlowers: { month: number; name: string }[] = [];
  mostCommonMeaning: { meaning: string; count: number } | null = null;

  constructor(private flowerService: FlowerService) {}

  ngOnInit(): void {
    this.getFlowersForSummerAutumn();
    this.getMostCommonMeaning();
  }

  searchByName(): void {
    this.flowerService.searchByName(this.searchWord).subscribe((flowers) => {
      this.flowers = flowers;
    });
  }

  getFlowersForSummerAutumn(): void {
    this.flowerService.getFlowersForSummerAutumn().subscribe((flowers) => {
      this.summerAutumnFlowers = flowers;
    });
  }

  getMostCommonMeaning(): void {
    this.flowerService.getMostCommonMeaning().subscribe((meaning) => {
      this.mostCommonMeaning = meaning;
    });
  }
}
