import { CommonModule } from '@angular/common';
import { Component, HostListener, Input } from '@angular/core';
import { Router, RouterModule } from '@angular/router';
import { FaConfig, FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { faBars, faCoins, faRightFromBracket, faRightToBracket } from '@fortawesome/free-solid-svg-icons';
import { MatSidenav } from '@angular/material/sidenav';
import { AuthService } from '../../../service/auth.service';
import { FlowerService } from '../../../service/flower.service';

@Component({
  selector: 'app-navbar',
  standalone: true,
  imports: [
    RouterModule,
    CommonModule,
    FontAwesomeModule
  ],
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.scss'
})
export class NavbarComponent {

  @Input() inputSidenav!: MatSidenav;
  @Input() inputSidenavState!: boolean;

  loggedToken = this.authService.loggedToken;

  faRightToBracket = faRightToBracket;
  faRightFromBracket = faRightFromBracket;
  faBars = faBars;
  faCoins = faCoins;

  prevScrollpos = window.scrollY || window.pageYOffset;
  isNavOpen: boolean = true;

  @HostListener('window:scroll', ['$event'])
  onScroll(event: Event) {
    const currentScrollPos = window.scrollY || window.pageYOffset;
    if (this.prevScrollpos > currentScrollPos) {
      this.isNavOpen = true;
    } else {
      this.isNavOpen = false;
    }
    this.prevScrollpos = currentScrollPos;
  }

  constructor(
    private authService: AuthService,
    faConfig: FaConfig,
    // private flowerService: FlowerService,
    private router: Router,
  ) {
    faConfig.fixedWidth = true;
    this.loggedToken = this.authService.loggedToken;
  }

  logout() {
    localStorage.removeItem('authToken');
    this.authService.setLoginData();
    this.loggedToken = false;
    this.router.navigate(['/']);
    location.reload();
  }

}
