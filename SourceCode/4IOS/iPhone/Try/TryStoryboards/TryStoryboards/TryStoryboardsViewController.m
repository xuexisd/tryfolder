//
//  TryStoryboardsViewController.m
//  TryStoryboards
//
//  Created by yeetong on 12-9-28.
//  Copyright (c) 2012年 yeetong. All rights reserved.
//

#import "TryStoryboardsViewController.h"
#import "NameDetailViewController.h"

@interface TryStoryboardsViewController ()

@end

@implementation TryStoryboardsViewController
{
    NSMutableArray *tableData;
    NSArray *searchResult;
}
@synthesize tableView1;


- (void)viewDidLoad
{
    [super viewDidLoad];
	// Do any additional setup after loading the view, typically from a nib.
    
    NSString *path=[[NSBundle mainBundle] pathForResource:@"ModelList" ofType:@"plist"];
    NSDictionary *dict=[[NSDictionary alloc]initWithContentsOfFile:path];
    tableData=[dict objectForKey:@"Name"];
    [tableView1 setContentOffset:CGPointMake(0, 65)];
}

- (void)viewDidUnload
{
    [self setTableView1:nil];
    [super viewDidUnload];
    // Release any retained subviews of the main view.
}

- (BOOL)shouldAutorotateToInterfaceOrientation:(UIInterfaceOrientation)interfaceOrientation
{
    return (interfaceOrientation != UIInterfaceOrientationPortraitUpsideDown);
}

-(NSInteger)tableView:(UITableView *)tableView numberOfRowsInSection:(NSInteger)section
{
    if(tableView == self.searchDisplayController.searchResultsTableView)
        return [searchResult count];
    else
        return [tableData count];
}

-(UITableViewCell *)tableView:(UITableView *)tableView cellForRowAtIndexPath:(NSIndexPath *)indexPath
{
    static NSString *tablename=@"TryCell";
    UITableViewCell *currentCell=[tableView dequeueReusableCellWithIdentifier:tablename];
    if(currentCell == nil)
    {
        currentCell=[[UITableViewCell alloc]initWithStyle:UITableViewCellStyleDefault reuseIdentifier:tablename];
    }
    if(tableView == self.searchDisplayController.searchResultsTableView)
    {
        currentCell.textLabel.text=[searchResult objectAtIndex:indexPath.row];
    }
    else
    {
        currentCell.textLabel.text=[tableData objectAtIndex:indexPath.row];
    }
    return currentCell;
    
}

-(void)tableView:(UITableView *)tableView didSelectRowAtIndexPath:(NSIndexPath *)indexPath
{
    
    if (tableView == self.searchDisplayController.searchResultsTableView) {
        [self performSegueWithIdentifier: @"showDetailPage" sender: self ];
    }
    [tableView deselectRowAtIndexPath:indexPath animated:YES];
}

-(void)prepareForSegue:(UIStoryboardSegue *)segue sender:(id)sender
{
//    if ([segue.identifier isEqualToString:@"showDetailPage"])
//    {
//        NSIndexPath *indexPath = [self.tableView1 indexPathForSelectedRow];
//        NameDetailViewController *destViewController = segue.destinationViewController;
//        destViewController.lblName =
//        [NSString stringWithFormat:@"%@, %@", [tableData objectAtIndex:indexPath.row], @"欢迎你"];
//    }
    if ([segue.identifier isEqualToString:@"showDetailPage"]) { NameDetailViewController *destViewController =
        segue.destinationViewController;
        NSIndexPath *indexPath = nil;
        if ([self.searchDisplayController isActive]) { indexPath =
            [self.searchDisplayController.searchResultsTableView indexPathForSelectedRow];
            destViewController.lblName = [searchResult objectAtIndex:indexPath.row];
        } else {
            indexPath = [self.tableView1 indexPathForSelectedRow]; destViewController.lblName = [tableData objectAtIndex:indexPath.row];
        }
        
        destViewController.hidesBottomBarWhenPushed=true;
    }
}

- (void)filterContentForSearchText:(NSString*)searchText scope:(NSString*)scope
{
    NSPredicate *resultPredicate = [NSPredicate predicateWithFormat:@"SELF contains[cd] %@",searchText];
    searchResult = [tableData filteredArrayUsingPredicate:resultPredicate];
}

-(BOOL)searchDisplayController:(UISearchDisplayController *)controller shouldReloadTableForSearchString:(NSString *)searchString
{
    [self filterContentForSearchText:searchString scope:[[self.searchDisplayController.searchBar scopeButtonTitles] objectAtIndex:[self.searchDisplayController.searchBar selectedScopeButtonIndex]]];
    return YES;
}

//- (NSArray *)sectionIndexTitlesForTableView:(UITableView *)tableView
//{
//
//    NSMutableArray *toBeReturned = [[NSMutableArray alloc]init];
//
//    for(char c = 'A';c<='Z';c++)
//
//        [toBeReturned addObject:[NSString stringWithFormat:@"%c",c]];
//
//    return toBeReturned;
//
//}
//- (NSInteger)tableView:(UITableView *)tableView sectionForSectionIndexTitle:(NSString *)title atIndex:(NSInteger)index
//{
//
//    NSInteger count = 0;
//
//    for(NSString *character in arrayOfCharacters)
//    {
//        if([character isEqualToString:title])
//        {
//            return count;
//        }
//        count ++;
//    }
//    return 0;
//
//}



@end
