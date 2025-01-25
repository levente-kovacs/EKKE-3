import { Component } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { ActivatedRoute, Router, RouterModule } from '@angular/router';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { User } from '../../model/user';
import { Observable, switchMap, of } from 'rxjs';
// import { UserService } from '../../service/user.service';
import { AuthService } from '../../service/auth.service';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [
    RouterModule,
    MatButtonModule,
    FontAwesomeModule,
    CommonModule,
    FormsModule
  ],
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss'
})
export class LoginComponent {

  user$: Observable<User> = this.activatedRoute.params.pipe(
    switchMap(params => {
      // if (params['id']) {
      //   return this.userService.get(params['id'])
      // }
      return of(new User())
    })
  );

  wasLoginSuccessful: boolean = true;

  constructor(
    private activatedRoute: ActivatedRoute,
    // private userService: UserService,
    private authService: AuthService,
    private router: Router,
  ) { }

  public login(email: string, password: string) {
    this.authService.login(email, password).subscribe(
      (response) => {
        localStorage.setItem('authToken', `${response.token}`);
        // this.authService.setLoginData();
        this.authService.loggedToken = true;
        this.router.navigate(['/']);
        console.log('Logged in successfully');
        location.reload();
        this.router.navigate(['/']);
      },
      (error) => {
        console.error('Login failed', error);
      }
      // next: (tokenObj: any) => {
      //   localStorage.setItem('authToken', `${tokenObj.token}`);
      //   // this.authService.setLoginData();
      //   this.authService.loggedToken = true;
      //   this.router.navigate(['/']);
      //   location.reload();
      //   // if (user.id && userFound.id == user.id && userFound.username == user.username && userFound.password == user.password) {
      //   //   this.wasLoginSuccessful = true;
      //   //   this.authService.setLoginData(user.id);
      //   // } else {
      //   //   this.wasLoginSuccessful = false;
      //   // }
      // },
      // error: () => {
      //   this.authService.loggedToken = false;
      // }
    );

    // user.id = user.username;
  //   if (user.id) {
  //     this.userService.get(user.id).subscribe({
  //       next: (userFound: User) => {
  //         if (user.id && userFound.id == user.id && userFound.username == user.username && userFound.password == user.password) {
  //           this.wasLoginSuccessful = true;
  //           this.authService.loggedUser$.next(userFound);
  //           localStorage.setItem('authToken', `${user.id}`);
  //           this.authService.setLoginData(user.id);
  //           this.router.navigate(['/']);
  //         } else {
  //           this.wasLoginSuccessful = false;
  //         }
  //       },
  //       error: () => {
  //         this.authService.loggedUser$.next(null);
  //         this.wasLoginSuccessful = false;
  //       }
  //       // complete: () => {
  //       // }
  //     });
  //   }
  //   this.wasLoginSuccessful = false;
  }

    // login(user: User) {
  //   this.authService.login(user).subscribe({
  //     next: (result: boolean) => {

  //     }

  //   })
  //   // user.id = user.username;
  //   console.log('wasLoginSuccessful', this.authService.wasLoginSuccessful);
  //   this.wasLoginSuccessful = this.authService.wasLoginSuccessful;
  //   if (this.wasLoginSuccessful) {
  //     console.log('YEEEY!');
  //     this.wasLoginSuccessful = true;
  //     this.router.navigate(['sign-up']);
  //     this.wasLoginSuccessful = true;
  //   } else {
  //     this.wasLoginSuccessful = false;
  //   }
  // }


}
