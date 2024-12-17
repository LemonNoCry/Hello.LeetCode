namespace Hello.LeetCode.Medium;

/// <summary>
/// You are given two non-empty linked lists representing two non-negative integers. The digits are stored in reverse order, and each of their nodes contains a single digit. Add the two numbers and return the sum as a linked list.
/// You may assume the two numbers do not contain any leading zero, except the number 0 itself.
/// </summary>
public class Problem2_AddTowNumbers
{
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
    {
        var dummyHead = new ListNode();
        var p1 = l1;
        var p2 = l2;
        var p3 = dummyHead;
        while (p1 != null || p2 != null)
        {
            p3.next ??= new ListNode();
            p3.next.val += (p1?.val ?? 0) + (p2?.val ?? 0);
            p3 = p3.next;
            if (p3.val >= 10)
            {
                p3.next = new ListNode(p3.val / 10);
                p3.val %= 10;
            }

            p1 = p1?.next;
            p2 = p2?.next;
        }

        return dummyHead.next;
    }

    public ListNode AddTwoNumbers2(ListNode l1, ListNode l2)
    {
        var dummyHead = new ListNode();
        var p1 = l1;
        var p2 = l2;
        var p3 = dummyHead;
        var carry = 0;
        while (p1 != null || p2 != null)
        {
            var x = p1?.val ?? 0;
            var y = p2?.val ?? 0;
            var sum = carry + x + y;
            carry = sum / 10;
            p3.next = new ListNode(sum % 10);
            p3 = p3.next;
            p1 = p1?.next;
            p2 = p2?.next;
        }

        if (carry > 0)
        {
            p3.next = new ListNode(carry);
        }

        return dummyHead.next;
    }
}

public class ListNode(int val = 0, ListNode? next = null)
{
    public int val = val;
    public ListNode? next = next;
}