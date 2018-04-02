const points = {
    regular: 1,
    bonus  : 1,
};

const regular   = () => points.regular,
      bonus     = (condition: boolean) => condition ? points.bonus : 0,
      hasBonus  = (days: number) => days > 1,
      withBonus = (days: number) => regular() + bonus(hasBonus(days));

export { regular, withBonus };
