import { Component, OnInit } from '@angular/core';
import { Member } from './member';
import { HomeService } from './home.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
})
export class HomeComponent implements OnInit {
  public members: Member[];

  constructor(private homeService: HomeService, private router: Router) { }

  ngOnInit(): void {
    this.homeService.getMembers().subscribe((members: Member[]) => {
      this.members = members;
    });
  }

  deleteMember(member: Member): void {
    this.homeService.deleteMember(member.id).subscribe(() => {
      this.members = this.members.filter(m => m !== member);
    });
  }

  editMember(member: Member): void {
    this.homeService.editMember = member;
    this.router.navigate(['/edit-member/', member.id]);
  }
}
