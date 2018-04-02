export enum Category {
    Children,
    Regular
}

export class Movie {
    constructor(
        readonly title: string,
        readonly category: Category,
        readonly isNewRelease: boolean,
    ) { }
}