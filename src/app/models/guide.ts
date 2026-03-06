export interface GuideSection {
  heading: string;
  content: string;
}

export interface Guide {
  slug: string;
  title: string;
  category: string;
  readTime: string;
  image: string;
  intro: string;
  sections: GuideSection[];
}

export type GuideSummary = Pick<Guide, 'slug' | 'title' | 'category' | 'readTime' | 'image' | 'intro'>;
