import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { RouterModule, Router, ActivatedRoute } from '@angular/router';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { faPlus, faSave, faSync } from '@fortawesome/free-solid-svg-icons';
import { Observable, switchMap, of } from 'rxjs';
import { Flower } from '../../model/flower';
import { FlowerService } from '../../service/flower.service';
import { AuthService } from '../../service/auth.service';

@Component({
  selector: 'app-flower-editor',
  standalone: true,
  imports: [
    FormsModule,
    CommonModule,
    FontAwesomeModule,
    MatButtonModule,
    RouterModule
  ],
  templateUrl: './flower-editor.component.html',
  styleUrl: './flower-editor.component.scss'
})
export class FlowerEditorComponent {

  flower$: Observable<Flower> = this.activatedRoute.params.pipe(
    switchMap(params => {
      if (params['id']) {
        return this.flowerService.getOne(params['id'])
      }
      // let newFlower = ;
      // newFlower.correctAnswer = 1;
      return of(new Flower())
    })
  );

  loggedToken = this.authService.loggedToken;

  meaningCount: number = 0;

  clicked: boolean = false;

  faSave = faSave;
  faSync = faSync;
  faPlus = faPlus;

  constructor(
    private router: Router,
    private activatedRoute: ActivatedRoute,
    private flowerService: FlowerService,
    private authService: AuthService
  ) {}

  onUpdate(flower: Flower): void {
    this.clicked = true;
    if (flower._id === '') {
      this.flowerService.getAll()
      .subscribe({
        error: (error) => console.log(error),
        next: () => {
          // flower._id = (parseInt(flowers[flowers.length - 1]._id) + 1).toString();
          this.flowerService.createFlower(flower)
          .subscribe({
            error: (error) => console.log(error),
            complete: () => {
              this.router.navigate(['flowers']);
            }
          });
        }
      })
    } else {
      this.flowerService.updateFlower(flower._id, flower)
      .subscribe({
        error: (error) => console.log(error),
        complete: () => {
          this.router.navigate(['flowers']);
        }
      });
    }
  }

  consoleWrite(obj: any) {
    console.log(obj);
  }

  addMeaningCount() {
    this.meaningCount++;
  }


}
