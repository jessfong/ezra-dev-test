import { Component } from '@angular/core';
import { HomeService } from '../home/home.service';
import { Router } from '@angular/router';
import { Member } from '../home/member';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-add-member',
  templateUrl: './add-member.component.html',
})
export class AddMemberComponent {
  newMember: Member = new Member('', '');

  constructor(public homeService: HomeService, private router: Router) { }

  addMember(): void {
    this.homeService.addMember(this.newMember).subscribe(() => {
      this.router.navigate(['/']);
    });
  }
}
