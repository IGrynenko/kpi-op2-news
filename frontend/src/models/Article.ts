class Article {
    title: string;
    text: string;
    authorId: number;
    categoryId: number;
    tags: number[];

    constructor(title: string, text: string, authorId: number, categoryId: number, tags: number[]) {
        this.title = title;
        this.text = text;
        this.authorId = authorId;
        this.categoryId = categoryId;
        this.tags = tags;
    }

}

export { Article }