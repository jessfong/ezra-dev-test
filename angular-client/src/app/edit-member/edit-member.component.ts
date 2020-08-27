import { Component, OnInit } from '@angular/core';
import { HomeService } from '../home/home.service';
import { Router, ActivatedRoute } from '@angular/router';
import { Member } from '../home/member';

@Component({
  selector: 'app-edit-member',
  templateUrl: './edit-member.component.html',
})
export class EditMemberComponent implements OnInit {

  constructor(public homeService: HomeService, private router: Router, private route: ActivatedRoute) { }

  ngOnInit(): void {
    if (!this.homeService.editMember) {
      const memberId = this.route.snapshot.paramMap.get('id');
      this.homeService.getMemberById(memberId).subscribe((member: Member) => {
        this.homeService.editMember = member;
      });
    }
  }

  save(): void {
    this.homeService.updateMember().subscribe(() => {
      this.router.navigate(['/']);
    });
  }
}
