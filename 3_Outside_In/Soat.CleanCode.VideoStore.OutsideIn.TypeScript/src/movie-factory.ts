import { Category, Movie } from './movie';

export const movies = {
    newReleaseChildren(id?: number) {
        return newRelease(id, Category.Children);
    },
    newReleaseRegular(id?: number) {
        return newRelease(id, Category.Regular);
    },
    children(id?: number) {
        return new Movie(formatTitle('Children', id), Category.Children, false);
    },
    regular(id?: number) {
        return new Movie(formatTitle('Regular', id), Category.Regular, false);
    },
    unknown() {
        return new Movie('Unknown', -1, false);
    }
};

function newRelease(id: number | undefined, category: Category) {
    return new Movie(formatTitle('NewRelease', id), category, true);
}

function formatTitle(title: string, id?: number) {
    return id
        ? title + id
        : title;
}
