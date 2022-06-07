import { Author } from './Author';
import { BaseModel } from './BaseModel';
import { Category } from './Category';
import { Tag } from './Tag';

export interface News extends BaseModel {
    title: string,
    text: string,
    author: Author
    category: Category,
    tags: Tag[]
};