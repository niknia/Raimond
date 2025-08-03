import { BasePage } from '@/components/layouts/BasePage';
import React, { useEffect, useState, useMemo } from 'react';
import { Stack, Box, Title, Text, Button, Group, Modal, TextInput } from '@mantine/core';
import { useCurQuestionanswers } from '@/data/curquestionanswers/curquestionanswers.query';
import { DkdGrid } from '@dkd-grid';
import type { ColumnDef } from '@tanstack/react-table';
import type { CurQuestionanswersDto } from '@/data/curquestionanswers/curquestionanswers.models';
import { useDisclosure } from '@mantine/hooks';
import { notifications } from '@mantine/notifications';

export default function IndexPage() {
    const { useGetAll, useCreate, useUpdate, useDelete } = useCurQuestionanswers();
    const { data: curQuestionanswersData, isLoading, refetch } = useGetAll();
    const createMutation = useCreate();
    const updateMutation = useUpdate();
    const deleteMutation = useDelete();
    
    const [selectedRowId, setSelectedRowId] = useState<string | null>(null);
    const [editingQuestionAnswer, setEditingQuestionAnswer] = useState<CurQuestionanswersDto | null>(null);
    const [opened, { open, close }] = useDisclosure(false);

    const data = curQuestionanswersData?.result || [];

    // تعریف ستون‌های جدول
    const columns = useMemo<ColumnDef<CurQuestionanswersDto>[]>(() => [
        {
            accessorKey: 'id',
            header: 'شناسه',
            size: 80,
        },
        {
            accessorKey: 'name',
            header: 'نام پاسخ سوال',
            size: 200,
        },
        {
            accessorKey: 'createTime',
            header: 'تاریخ ایجاد',
            size: 150,
            cell: ({ getValue }: { getValue: () => any }) => {
                const date = getValue() as string;
                return date ? new Date(date).toLocaleDateString('fa-IR') : '-';
            },
        },
    ], []);

    // هندل‌های CRUD
    const handleEdit = (row: CurQuestionanswersDto) => {
        setEditingQuestionAnswer(row);
        open();
    };

    const handleDelete = async (row: CurQuestionanswersDto) => {
        try {
            await deleteMutation.mutateAsync(row.id);
            notifications.show({
                title: 'موفقیت',
                message: 'پاسخ سوال با موفقیت حذف شد',
                color: 'green',
            });
            refetch();
        } catch (error) {
            notifications.show({
                title: 'خطا',
                message: 'خطا در حذف پاسخ سوال',
                color: 'red',
            });
        }
    };

    const handleAdd = () => {
        setEditingQuestionAnswer(null);
        open();
    };

    const handleSave = async (values: Partial<CurQuestionanswersDto>) => {
        try {
            if (editingQuestionAnswer) {
                await updateMutation.mutateAsync({ id: editingQuestionAnswer.id, ...values });
                notifications.show({
                    title: 'موفقیت',
                    message: 'پاسخ سوال با موفقیت ویرایش شد',
                    color: 'green',
                });
            } else {
                await createMutation.mutateAsync(values);
                notifications.show({
                    title: 'موفقیت',
                    message: 'پاسخ سوال جدید با موفقیت ایجاد شد',
                    color: 'green',
                });
            }
            close();
            refetch();
        } catch (error) {
            notifications.show({
                title: 'خطا',
                message: 'خطا در ذخیره‌سازی',
                color: 'red',
            });
        }
    };

    return (
        <BasePage>
            <Stack gap="lg">
                <Box>
                    <Title order={2}>مدیریت پاسخ‌های سوالات</Title>
                    <Text c="dimmed">مدیریت پاسخ‌های مختلف سوالات</Text>
                </Box>

                <DkdGrid
                    columns={columns}
                    data={data}
                    isLoading={isLoading}
                    rtl
                    height={600}
                    selectedRowId={selectedRowId}
                    onRowClick={(row: any) => setSelectedRowId(row.original.id.toString())}
                    onEdit={handleEdit}
                    onDelete={handleDelete}
                    onAdd={handleAdd}
                    initialPageSize={15}
                />

                {/* Modal برای افزودن/ویرایش */}
                <Modal 
                    opened={opened} 
                    onClose={close} 
                    title={editingQuestionAnswer ? 'ویرایش پاسخ سوال' : 'افزودن پاسخ سوال جدید'}
                    size="md"
                >
                    <Stack gap="md">
                        <TextInput
                            label="نام پاسخ سوال"
                            placeholder="نام پاسخ سوال"
                            defaultValue={editingQuestionAnswer?.name || ''}
                            name="name"
                            required
                        />
                        
                        <Group justify="flex-end" mt="md">
                            <Button variant="outline" onClick={close}>
                                انصراف
                            </Button>
                            <Button 
                                onClick={() => {
                                    const formData = new FormData(document.querySelector('form') as HTMLFormElement);
                                    const values = {
                                        name: (formData.get('name') as string) || '',
                                    };
                                    handleSave(values);
                                }}
                                loading={createMutation.isPending || updateMutation.isPending}
                            >
                                {editingQuestionAnswer ? 'ویرایش' : 'افزودن'}
                            </Button>
                        </Group>
                    </Stack>
                </Modal>
            </Stack>
        </BasePage>
    );
} 