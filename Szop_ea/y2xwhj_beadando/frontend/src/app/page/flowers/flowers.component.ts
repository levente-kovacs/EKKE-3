import { CommonModule } from '@angular/common';
import { Component, Renderer2 } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { RouterModule, Router } from '@angular/router';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { faCircleCheck, faCircleXmark, faCheck, faXmark, faPenToSquare, faTrashCan, faSquarePlus, faSave } from '@fortawesome/free-solid-svg-icons';
import { FlowerService } from '../../service/flower.service';
import { Flower } from '../../model/flower';
import { AuthService } from '../../service/auth.service';

@Component({
  selector: 'app-flowers',
  standalone: true,
  imports: [
    CommonModule,
    MatButtonModule,
    RouterModule,
    FontAwesomeModule

  ],
  templateUrl: './flowers.component.html',
  styleUrl: './flowers.component.scss'
})
export class FlowersComponent {

  list$ = this.flowerService.getAll();

  loggedToken = this.authService.loggedToken;

  faCircleCheck = faCircleCheck;
  faCircleXmark = faCircleXmark;
  faCheck = faCheck;
  faXmark = faXmark;
  faPenToSquare = faPenToSquare;
  faTrashCan = faTrashCan;
  faSquarePlus = faSquarePlus;
  faSave = faSave;

  constructor(
    private flowerService: FlowerService,
    private router: Router,
    private renderer: Renderer2,
    private authService: AuthService
  ) {  }

  ngOnInit(): void {
    this.renderer.setProperty(window, 'scrollTo', [0, 0]);
  }

  onEditOne(flower: Flower): void {
    console.log();
    this.router.navigate([`flower-editor/${flower._id}`]);
  }

  deleteflower(id: string): void {
    this.flowerService.deleteFlower(id).subscribe({
      error: (err) => console.log('Error: ', err),
      complete: () => {
        this.list$ = this.flowerService.getAll();
      }
    });
  }

}
