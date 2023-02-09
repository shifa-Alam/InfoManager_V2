import { BaseEntity } from "./baseEntity";

export class MemberSkill extends BaseEntity {
  memberId: number = 0;
  skillId: number = 0;
  isSelect: boolean = false;
  skillName: string = ''
}

